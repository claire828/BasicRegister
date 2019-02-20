
using System.Collections;
using System.Collections.Generic;

public class Main
{
    public enum DepositUIStyle
    {
        Common = 1,
        Friend = 2,
        TopUp = 3
    }

    private BasicRegister<DepositUIStyle, IPanel> UIManager;


    public Main()
    {
        RegisterPanel();
    }


    private void RegisterPanel()
    {
        UIManager = new BasicRegister<DepositUIStyle, IPanel>();
        UIManager.RegisterType(DepositUIStyle.Friend, typeof(FriendPanel));
        UIManager.RegisterType(DepositUIStyle.TopUp, typeof(TopUpPanel));
        UIManager.RegisterType(DepositUIStyle.Common, typeof(CommonPanel));
    }


  
    public void GenerateImp(DepositUIStyle style)
    {
        var imp = UIManager.Resolve(style); 
    }

    public void GenerateImpWithConstructor(DepositUIStyle style, object[] arrs)
    {
        var imp = UIManager.Resolve(style, arrs);
    }

}





class FriendPanel : IPanel
{
    public void Execute() { Debug.Log("generating FriendPanel success "); }

}

class TopUpPanel : IPanel
{
    public void Execute() { Debug.Log("generating TopUpPanel success "); }

}

class CommonPanel : IPanel
{
    public void Execute() { Debug.Log("generating CommonPanel success "); }

}


