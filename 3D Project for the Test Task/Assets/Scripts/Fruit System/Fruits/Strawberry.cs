namespace FruitSystem.Fruits
{
    public sealed class Strawberry : Fruit
    {
        protected override void Start()
        {
            base.Start();
            _currentTypeFruit = TypeFruit.Strawberry;
        }
        public override void Accept(ICollisionVisitor collison)
        {
            collison.Visitor(this);
        }
    }
}