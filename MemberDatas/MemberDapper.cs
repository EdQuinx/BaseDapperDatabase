using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DapperDatabase.MemberDatas
{
    public class MemberDapper : IDisposable
    {
        #region Properties
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Dapper m_data;
        public Dapper Data
        {
            get { return m_data; }
        }
        #endregion
        #region Methods
        public MemberDapper()
        {
            m_data = new Dapper("member");
        }
        #endregion
        #region Disposes
        public void Dispose()
        {
            m_data.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
