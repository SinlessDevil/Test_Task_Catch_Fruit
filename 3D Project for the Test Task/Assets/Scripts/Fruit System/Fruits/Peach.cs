namespace FruitSystem.Fruits
{
    public sealed class Peach : Fruit
    {
        protected override void Start()
        {
            base.Start();
            _currentTypeFruit = TypeFruit.Peach;
        }
        public override void Accept(ICollisionVisitor collison)
        {
            collison.Visitor(this);
        }
    }
}