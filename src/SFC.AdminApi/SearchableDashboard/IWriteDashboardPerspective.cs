namespace SFC.AdminApi.SearchableDashboard
{
  internal interface IWriteDashboardPerspective 
  {
    void Add(SearchableDashboardEntry searchableDashboardEntry);
    SearchableDashboardEntry Get(string eventLoginName);
    void Update(SearchableDashboardEntry searchableDashboardEntry);
  }
}