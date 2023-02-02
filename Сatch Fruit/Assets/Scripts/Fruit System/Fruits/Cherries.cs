namespace FruitSystem.Fruits
{
    public class Cherries : Fruit
    {
        protected override void Start()
        {
            base.Start();
            _currentTypeFruit = TypeFruit.Cherries;
        }
        public override void Accept(ICollisionVisitor collison)
        {
            collison.Visitor(this);
        }
    }
}