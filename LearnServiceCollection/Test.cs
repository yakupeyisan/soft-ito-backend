namespace LearnServiceCollection;
public class Test
{
    private int i=0;
    public int Get(){
        i++;
        return i;
    }
}
public class Manager{
    public Manager(Test test){
        test.Get();
    }
}