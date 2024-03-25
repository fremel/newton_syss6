namespace Exercise_03c.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void RegisterUser_UserNameShouldBeUnique_CaseInsensitive()
    {
        UserRegistration userRegistration = new UserRegistration();
        bool registeredFirstTime = userRegistration.RegisterUser("kimp");

        bool registeredSecondTime = userRegistration.RegisterUser("KimP");

        Assert.IsTrue(registeredFirstTime);
        Assert.IsFalse(registeredSecondTime);
    }
}