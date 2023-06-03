
namespace ProcketZone2.UI
{
    public class Bag : Form
    {
        private void Start()
        {
            Close();
        }
        public override void Close()
        {
            gameObject.SetActive(false);
        }

        public override void Open()
        {
            gameObject.SetActive(true);
        }
    }

}
