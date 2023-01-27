namespace FruitSystem.Fruits
{
    public class Avocado : Fruit
    {
        protected override void Start()
        {
            base.Start();
            _currentTypeFruit = TypeFruit.Avocado;
        }
        public override void Accept(ICollisionVisitor collison)
        {
            collison.Visitor(this);
        }
    }
}