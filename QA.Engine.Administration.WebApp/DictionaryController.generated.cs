// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace QA.Engine.Administration.WebApp.Controllers
{
    public partial class DictionaryController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public DictionaryController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected DictionaryController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult AjaxDiscriminators()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AjaxDiscriminators);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult AjaxKendoUIRegions()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AjaxKendoUIRegions);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult AjaxRegions()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AjaxRegions);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public DictionaryController Actions { get { return MVC.Dictionary; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Dictionary";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Dictionary";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string AjaxCultures = "AjaxCultures";
            public readonly string AjaxDiscriminators = "AjaxDiscriminators";
            public readonly string AjaxDiscriminatorConstraints = "AjaxDiscriminatorConstraints";
            public readonly string AjaxKendoUIRegions = "AjaxKendoUIRegions";
            public readonly string AjaxRegions = "AjaxRegions";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string AjaxCultures = "AjaxCultures";
            public const string AjaxDiscriminators = "AjaxDiscriminators";
            public const string AjaxDiscriminatorConstraints = "AjaxDiscriminatorConstraints";
            public const string AjaxKendoUIRegions = "AjaxKendoUIRegions";
            public const string AjaxRegions = "AjaxRegions";
        }


        static readonly ActionParamsClass_AjaxDiscriminators s_params_AjaxDiscriminators = new ActionParamsClass_AjaxDiscriminators();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AjaxDiscriminators AjaxDiscriminatorsParams { get { return s_params_AjaxDiscriminators; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AjaxDiscriminators
        {
            public readonly string viewModel = "viewModel";
        }
        static readonly ActionParamsClass_AjaxKendoUIRegions s_params_AjaxKendoUIRegions = new ActionParamsClass_AjaxKendoUIRegions();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AjaxKendoUIRegions AjaxKendoUIRegionsParams { get { return s_params_AjaxKendoUIRegions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AjaxKendoUIRegions
        {
            public readonly string viewModel = "viewModel";
        }
        static readonly ActionParamsClass_AjaxRegions s_params_AjaxRegions = new ActionParamsClass_AjaxRegions();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AjaxRegions AjaxRegionsParams { get { return s_params_AjaxRegions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AjaxRegions
        {
            public readonly string viewModel = "viewModel";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_DictionaryController : QA.Engine.Administration.WebApp.Controllers.DictionaryController
    {
        public T4MVC_DictionaryController() : base(Dummy.Instance) { }

        partial void AjaxCulturesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult AjaxCultures()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AjaxCultures);
            AjaxCulturesOverride(callInfo);
            return callInfo;
        }

        partial void AjaxDiscriminatorsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, QA.Engine.Administration.WebApp.Models.Dictionary.ReadDiscriminatorsViewModel viewModel);

        public override System.Web.Mvc.ActionResult AjaxDiscriminators(QA.Engine.Administration.WebApp.Models.Dictionary.ReadDiscriminatorsViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AjaxDiscriminators);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            AjaxDiscriminatorsOverride(callInfo, viewModel);
            return callInfo;
        }

        partial void AjaxDiscriminatorConstraintsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult AjaxDiscriminatorConstraints()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AjaxDiscriminatorConstraints);
            AjaxDiscriminatorConstraintsOverride(callInfo);
            return callInfo;
        }

        partial void AjaxKendoUIRegionsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, QA.Engine.Administration.WebApp.Models.SiteMap.ReadRegionsViewModel viewModel);

        public override System.Web.Mvc.ActionResult AjaxKendoUIRegions(QA.Engine.Administration.WebApp.Models.SiteMap.ReadRegionsViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AjaxKendoUIRegions);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            AjaxKendoUIRegionsOverride(callInfo, viewModel);
            return callInfo;
        }

        partial void AjaxRegionsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, QA.Engine.Administration.WebApp.Models.SiteMap.ReadRegionsViewModel viewModel);

        public override System.Web.Mvc.ActionResult AjaxRegions(QA.Engine.Administration.WebApp.Models.SiteMap.ReadRegionsViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AjaxRegions);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            AjaxRegionsOverride(callInfo, viewModel);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
