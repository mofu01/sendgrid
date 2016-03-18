using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Models.Statistics;

namespace SendGrid.Endpoints
{
    public class Statistics
    {
        private readonly string globalEndpoint = "v3/stats";
        private readonly string categoryEndpoint = "v3/categories/stats";
        private readonly string subUserEndpoint = "v3/subusers/stats";
        private readonly ApiClient client;

        /// <summary>
        /// SendGrid Statistics object.
        /// Basic Global https://sendgrid.com/docs/API_Reference/Web_API_v3/Stats/global.html
        /// Basic Category https://sendgrid.com/docs/API_Reference/Web_API_v3/Stats/categories.html
        /// Basic SubUser https://sendgrid.com/docs/API_Reference/Web_API_v3/Stats/subusers.html
        /// </summary>
        /// <param name="client">SendGrid Web API v3 client</param>
        public Statistics(ApiClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Global Stats provide all of your user’s email statistics for a given date range.
        /// </summary>
        /// <param name="startDate">The starting date of the statistics to retrieve</param>
        /// <param name="endDate">The end date of the statistics to retrieve. Defaults to today.</param>
        /// <param name="aggregatedBy">How to group the statistics (Day, Week, Month)</param>
        /// <returns></returns>
        public IDictionary<DateTime, BasicStatistic> GetBasicGlobal(DateTime startDate, DateTime? endDate = null, AggregateType? aggregatedBy = null)
        {

        }

        /// <summary>
        /// Category Stats provide all of your user’s email statistics for your categories.
        /// </summary>
        /// <param name="startDate">The starting date of the statistics to retrieve</param>
        /// <param name="categories">The categories to get statistics for, up to 10</param>
        /// <param name="endDate">The end date of the statistics to retrieve. Defaults to today.</param>
        /// <param name="aggregatedBy">How to group the statistics (Day, Week, Month)</param>
        /// <returns></returns>
        public IDictionary<DateTime, BasicStatistic> GetBasicFilterdByCategories(DateTime startDate, IEnumerable<string> categories, DateTime? endDate = null, AggregateType? aggregatedBy = null)
        {

        }

        /// <summary>
        /// Subuser Stats provide all of your user’s email statistics for your subuser accounts.
        /// </summary>
        /// <param name="startDate">The starting date of the statistics to retrieve</param>
        /// <param name="subUsers">The subusers to get statistics for, up to 10</param>
        /// <param name="endDate">The end date of the statistics to retrieve. Defaults to today.</param>
        /// <param name="aggregatedBy">How to group the statistics (Day, Week, Month)</param>
        /// <returns></returns>
        public IDictionary<DateTime, BasicStatistic> GetBasicFilterdBySubUsers(DateTime startDate, IEnumerable<string> subUsers, DateTime? endDate = null, AggregateType? aggregatedBy = null)
        {

        }
    }
}
