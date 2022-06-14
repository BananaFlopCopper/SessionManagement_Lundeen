using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;

namespace SessionManagement
{
    public class HashModule : IHttpModule
    {
        public NameValueCollection Q { get; set; }
        public void Dispose()
        {
            // nothing to dispose
        }

        public void Init(HttpApplication context)
        {
            //context.BeginRequest += new EventHandler(OnBeginRequest);
            //context.EndRequest += new EventHandler(OnEndRequest);
            context.PreRequestHandlerExecute += new EventHandler(PreRequestHandlerExecute);
            Q = new NameValueCollection();
        }
        public void PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            string Query = context.Request.Url.Query;
            // make sure session and query are not null, and makes sure at least one query is not in the current session.
            if (context.Session == null) return;
            if (Query == "" || Query == null) return;
            if (HttpContext.Current.Session[context.Request.QueryString["u"]] != null) return;

            string URL = context.Request.Url.AbsolutePath;
            List<int> vars = new List<int>();

            //Attempt to find all variables in querystring
            for (int i = Query.IndexOf('='); i > -1; i = Query.IndexOf('=', i + 1))
            { vars.Add(i); }

            for (int i = 0; i < vars.Count; i++)
            {
                //put the current found var into input, then hash it
                string value = context.Request.QueryString["" + Query[vars[i] - 1]];
                string key = Hasher(value);
                // prevent duplicates
                while (HttpContext.Current.Session[key] != null)
                {
                    key = Hasher(value);
                }
                HttpContext.Current.Session[key] = value;

                //change the query string to hashed value
                if (i == 0)
                { URL += "?" + Query[vars[i] - 1] + "=" + key; }
                else
                { URL += "&" + Query[vars[i] - 1] + "=" + key; }

            }

            context.Response.Redirect(URL);
        }
        private string Hasher(string input)
        {
            Random random = new Random();
            return random.Next(2000000000).ToString();
        }

    }
}