using DD4T.ContentModel.Factories;
using DD4T.Factories;
using DD4T.Mvc.Controllers;
using DD4T.Mvc.Html;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Playground.Website.Controllers
{
    public class PageController : TridionControllerBase
    {

        private Regex reDefaultPage = new Regex(@".*/[^/\.]*(/?)$");

        public PageController()
        {
            componentPresentationRenderer = new DefaultComponentPresentationRenderer();
        }

        private DD4T.Factories.PageFactory _pageFactory = null;
        private string _defaultPageFileName = null;


        public override DD4T.ContentModel.Factories.IPageFactory PageFactory
        {
            get
            {
                if (_pageFactory == null)
                {
                    _pageFactory = new PageFactory();
                    _pageFactory.LinkFactory = new LinkFactory();
                }
                return _pageFactory;
            }
        }
        public string DefaultPageFileName
        {
            get
            {
                if (_defaultPageFileName == null)
                {
                    _defaultPageFileName = ConfigurationManager.AppSettings["DD4T.DefaultPage"];
                }
                return _defaultPageFileName;
            }
        }

        public override ActionResult Page(string pageId)
        {
            if (string.IsNullOrEmpty(pageId))
            {
                pageId = DefaultPageFileName;
            }
            else
            {
                if (reDefaultPage.IsMatch("/" + pageId))
                {
                    if (pageId.EndsWith("/"))
                    {
                        pageId += DefaultPageFileName;
                    }
                    else
                    {
                        pageId += "/" + DefaultPageFileName;
                    }
                }
            }
            return base.Page(pageId);
        }

    }
}