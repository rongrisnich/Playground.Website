using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DD4T.Mvc.Controllers;
using System.Web.Mvc;
using DD4T.ContentModel;
using DD4T.ContentModel.Exceptions;
using DD4T.Factories;
using System.Reflection;
//using BuildingBlocks.DD4T.MarkupModels;
using DD4T.Mvc.Html;
using DD4T.ContentModel.Factories;

namespace Playground.Website.Controllers
{
    public class ComponentController : TridionControllerBase
    {
        public ComponentController()
        {
            ComponentFactory = new ComponentFactory();
        }
        private IComponentFactory _componentFactory = null;
        public override DD4T.ContentModel.Factories.IComponentFactory ComponentFactory
        {
            get
            {
                if (_componentFactory == null)
                    _componentFactory = new ComponentFactory();
                return _componentFactory;
            }
        }


    }
}
