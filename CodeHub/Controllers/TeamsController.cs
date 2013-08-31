using MonoTouch.Dialog;
using GitHubSharp.Models;
using System.Collections.Generic;
using MonoTouch.UIKit;
using System.Linq;
using CodeHub.Controllers;
using CodeFramework.Controllers;
using CodeFramework.Elements;
using System.Threading.Tasks;

namespace CodeHub.Controllers
{
    public class TeamsController : ListController<TeamShortModel>
    {
        public string OrganizationName { get; private set; }

        public TeamsController(IListView<TeamShortModel> view, string organizationName)
            : base(view)
        {
            OrganizationName = organizationName;
        }

        public override void Update(bool force)
        {
            var response = Application.Client.Organizations[OrganizationName].GetTeams(force);
            Model = new ListModel<TeamShortModel> { Data = response.Data };
            Model.More = this.CreateMore(response);
        }
    }
}