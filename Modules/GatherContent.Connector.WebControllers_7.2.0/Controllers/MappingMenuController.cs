namespace GatherContent.Connector.WebControllers_7._2._0.Controllers
{
    //[PluginController("GatherContent")]
    ////[global::Umbraco.Web.Trees.Tree("GatherContent", "GatherContentTree", "Gather Connect", iconClosed: "icon-newspaper-alt")]
    //public class MappingMenuController : TreeController
    //{
    //    private readonly IMappingManager _mappingManager;

    //    public MappingMenuController(IMappingManager mappingManager)
    //    {
    //        _mappingManager = mappingManager;
    //    }

    //    [System.Web.Http.HttpGet]
    //    public Umbraco.Web.Models.Trees.TreeNodeCollection GetMappingsNode()
    //    {
    //        var result = new TreeNodeCollection();
    //        try
    //        {
    //            var mappingController = new MappingController(_mappingManager);
    //            result.AddRange(mappingController.GetMappingMenu().Where(mapping => mapping.LastUpdatedDate != "Removed from GatherContent")
    //                .Select(mapping =>
    //                    this.CreateTreeNode(mapping.MappingId.ToString(), "mappings", null, mapping.MappingTitle, "icon-command",
    //                    "GatherContent/GatherContentTree/mappings.edit/" + mapping.MappingId + @"?gcId=" + mapping.GcTemplate.Id)));
    //            return result;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }
    //    }

    //    protected override Umbraco.Web.Models.Trees.MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
