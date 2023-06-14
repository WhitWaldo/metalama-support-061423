using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

public sealed class EntityStoreAttribute : TypeAspect
{
    [Introduce]
    protected object _lockObj = new();

    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        //var lockObj = builder.Advice.IntroduceField((INamedType)TypeFactory.GetType(typeof(object)), "_lockObj",
        //    IntroductionScope.Default, OverrideStrategy.Ignore,
        //    b =>
        //    {
        //        b.Accessibility = Accessibility.Private;
        //        b.InitializerExpression = ExpressionFactory.Parse("new()");
        //    });

        var method = builder.Advice.IntroduceMethod(builder.Target, nameof(DoSomething), IntroductionScope.Default,
            OverrideStrategy.New,
            b =>
            {
                b.Accessibility = Accessibility.Private;
            }, args: new
            {
                //lockObject = lockObj
            });
    }

    [Template]
    private void DoSomething()// (object lockObject)
    {

    }
}
