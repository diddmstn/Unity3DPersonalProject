

public class Potal : InteractionObj
{
    protected override void startAction()
    {
        GameManager.instance.EnterGame();
    }
}
