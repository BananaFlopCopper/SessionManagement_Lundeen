using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace SessionManagement
{
	public class FooterModule : IHttpModule
	{
		public void Dispose()
		{
			// nothing to dispose
		}

	  public void Init(HttpApplication context)
		{
			context.BeginRequest += new EventHandler(OnBeginRequest);
			context.EndRequest += new EventHandler(OnEndRequest);
		}

		private void OnEndRequest(object sender, EventArgs e)
		{
			HttpContext context = ((HttpApplication)sender).Context;
			
			string URL = context.Request.Path;
			string pass = context.Request.QueryString["p"];
			NameValueCollection Q = context.Request.QueryString;
			context.Response.Write("<h4>Hello From the HttpModule</h4>");
		}

		private void OnBeginRequest(object sender, EventArgs e)
		{
			HttpContext context = ((HttpApplication)sender).Context;
			string URL = context.Request.Path;
			NameValueCollection Q = context.Request.QueryString;
		}
	}
}