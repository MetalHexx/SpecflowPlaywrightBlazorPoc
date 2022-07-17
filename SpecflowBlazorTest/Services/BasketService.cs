namespace SpecflowBlazorTest.Services
{
    public interface IBasketService
    {
        int ItemCount { get; }
        void AddItem();
    }

    public class BasketService : IBasketService
    {
        public int ItemCount { get; private set; }

        public void AddItem()
        {
            ItemCount++;
        }
    }
}
