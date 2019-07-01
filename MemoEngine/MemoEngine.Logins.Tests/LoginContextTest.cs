using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MemoEngine.Logins.Tests
{
    [TestClass]
    public class LoginContextTest
    {
        /// <summary>
        /// 컨텍스트 클래스 테스트 
        /// </summary>
        [TestMethod]
        public void LoginContextClassRunOk()
        {            
            using (LoginContext loginContext = new LoginContext())
            {
                // TODO
                Assert.AreEqual("OK", "OK");
            }
        }

        /// <summary>
        /// Logins 테이블에 대한 읽기 테스트 
        /// </summary>
        [TestMethod]
        public void GetLoginsTableData()
        {
            using (var db = new LoginContext())
            {
                var logins = db.Logins.ToList();
                Assert.IsTrue(logins.Count > -1);
            }
        }
    }
}
