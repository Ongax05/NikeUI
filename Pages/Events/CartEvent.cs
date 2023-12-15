using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NikeUI.ApiServices.Dtos;

namespace NikeUI.Pages.Events
{
    public class CartEvent
    {
        public List<ProductoDto> ProductsInCart { get; private set; } = [];
        public event Action CartAction;
        public void AddToCartEvent(ProductoDto product)
        {
            ProductsInCart.Add(product);
            CartAction?.Invoke();
            ExecuteAction();
        }

        public void DisposeToCartEvent()
        {
            ProductsInCart.Clear();
            CartAction?.Invoke();
            ExecuteAction();
        }
        private void ExecuteAction () => CartAction?.Invoke();
    }
}