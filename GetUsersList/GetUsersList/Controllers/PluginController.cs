using Alchemy4Tridion.Plugins;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using Tridion.ContentManager.CoreService.Client;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Collections.Generic;

namespace GetUsersList.Controllers
{
    /// <summary>
    /// An ApiController to create web services that your plugin can interact with.
    /// </summary>
    /// <remarks>
    /// The AlchemyRoutePrefix accepts a Service Name as its first parameter.  This will be used by both
    /// the generated Url's as well as the generated JS proxy.
    /// <c>/Alchemy/Plugins/{YourPluginName}/api/{ServiceName}/{action}</c>
    /// <c>Alchemy.Plugins.YourPluginName.Api.Service.action()</c>
    /// 
    /// The attribute is optional and if you exclude it, url's and methods will be attached to "api" instead.
    /// <c>/Alchemy/Plugins/{YourPluginName}/api/{action}</c>
    /// <c>Alchemy.Plugins.YourPluginName.Api.action()</c>
    /// </remarks>
    [AlchemyRoutePrefix("Service")]
    public class PluginController : AlchemyApiController
    {
        /// // GET /Alchemy/Plugins/{YourPluginName}/api/{YourServiceName}/YourRoute
        /// <summary>
        /// Just a simple example..
        /// </summary>
        /// <returns>A string "Your Response" as the response message.</returns>
        /// </summary>
        /// <remarks>
        /// All of your action methods must have both a verb attribute as well as the RouteAttribute in
        /// order for the js proxy to work correctly.
        /// </remarks>
        [HttpGet]
        [Route("Hello")]
        public string SayHello()
        {
            List<TridionUserDetails> AuthorList = new List<TridionUserDetails>();
            var filter = new UsersFilterData { IsPredefined = false };
            var users = Client.GetSystemWideList(filter);
            foreach (TrusteeData user in users)
            {
                //if (user.Id == "tcm:0-15-65552" || user.Id == "tcm:0-15-65552")
                //{
                    AuthorList.Add(new TridionUserDetails(user.Id, user.Description, user.Title, user.IsEditable));
                //}

            }
            var output = JsonConvert.SerializeObject(AuthorList);

            return output.ToString();
        }
    }
}

public class TridionUserDetails
{
    private string tcmuri;
    private string name;
    private string title;
    private bool? isEditable;


    public TridionUserDetails(string tcmuri, string name, string title, bool? isEditable)
    {
        this.tcmuri = tcmuri;
        this.name = name;
        this.title = title;
        this.isEditable = isEditable;


    }

    public string Tcmuri
    {
        get { return tcmuri; }
        set { tcmuri = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string UserId
    {
        get { return title; }
        set { title = value; }
    }

    public bool? IsEditable
    {
        get { return isEditable; }
        set { isEditable = value; }
    }


}