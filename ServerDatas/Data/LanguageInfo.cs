using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDatabase.ServerDatas.Data
{
    public class LanguageInfo
    {
		private string m_messageName;

		public string MessageName
		{
			get { return m_messageName; }
			set { m_messageName = value; }
		}
		private string m_vietnamMsg;

		public string VietnamMsg
		{
			get { return m_vietnamMsg; }
			set { m_vietnamMsg = value; }
		}

	}
}
