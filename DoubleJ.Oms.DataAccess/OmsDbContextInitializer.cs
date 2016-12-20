using System.Data.Entity;

namespace DoubleJ.Oms.DataAccess
{
    public class OmsDbContextInitializer : CreateDatabaseIfNotExists<OmsContext>
    {
        /// <summary>
        ///     The seed.
        /// </summary>
        /// <param name="context">
        ///     The context.
        /// </param>
        protected override void Seed(OmsContext context)
        {
        }
    }
}