namespace FruitSystem.Fruits
{
    public sealed class Apple : Fruit
    {
        protected override void Start()
        {
            base.Start();
            _currentTypeFruit = TypeFruit.Apple;
        }
        public override void Accept(ICollisionVisitor collison)
        {
            collison.Visitor(this);
        }
    }
}