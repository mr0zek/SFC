namespace SFC.AdminApi.SearchableDashboard
{
  public interface ISearchabelDashboardPerspective
  {
    SearchableDashboardResult Search(SearchableDashboardQueryModel query);
  }
}