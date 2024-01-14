using Microsoft.AspNetCore.Mvc.RazorPages;
using CarService.Data;

namespace CarService.Models
{
    public class ServiceGroupsPageModel:PageModel
    {
        public List<AssignedGroupData> AssignedGrouptDataList;

        public void PopulateAssignedGroupData(CarServiceContext context, Service service)
        {
            var allGroups = context.Group;
            var serviceGroups = new HashSet<int>(
                service.ServiceGroups.Select(g => g.GroupID));
            AssignedGrouptDataList = new List<AssignedGroupData>();
            foreach(var gr in allGroups)
            {
                AssignedGrouptDataList.Add(new AssignedGroupData
                {
                    GroupID = gr.ID,
                    Name = gr.CategoryName,
                    Assigned = serviceGroups.Contains(gr.ID)

                }) ;
                

            }
        }

        public void UpdateServiceGroups(CarServiceContext context, string[] selectedGroups, Service serviceToUpdate)
        {
            if (selectedGroups == null)
            {
                serviceToUpdate.ServiceGroups = new List<ServiceGroup>();
                return;
            }

            var selectedGroupsHS = new HashSet<string>(selectedGroups);
            var serviceGroups = new HashSet<int>(serviceToUpdate.ServiceGroups.Select(g => g.Group.ID));
            foreach(var gr in context.Group) {
                if (selectedGroupsHS.Contains(gr.ID.ToString()))
                {
                    if (!serviceGroups.Contains(gr.ID))
                    {
                        serviceToUpdate.ServiceGroups.Add(
                            new ServiceGroup
                            {
                                ServiceID = serviceToUpdate.ServiceId,
                                GroupID = gr.ID
                            });
                    }
                }
                else
                {
                    if(serviceGroups.Contains(gr.ID))
                    {
                        ServiceGroup courseToRemove = serviceToUpdate.ServiceGroups.SingleOrDefault(i => i.GroupID == gr.ID);
                        context.Remove(courseToRemove);
                    }
                }

            }
        }
    }
}
