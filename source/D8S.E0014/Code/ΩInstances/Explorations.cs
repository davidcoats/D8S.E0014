using System;


namespace D8S.E0014
{
    public class Explorations : IExplorations
    {
        #region Infrastructure

        public static IExplorations Instance { get; } = new Explorations();


        private Explorations()
        {
        }

        #endregion
    }
}
