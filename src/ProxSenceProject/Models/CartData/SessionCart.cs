using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ProxSenceProject.ProjectDataSet;

namespace ProxSenceProject.Models.CartData
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart sessionCart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            sessionCart.Session = session;
            return sessionCart;
        }


        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Project project, int quantity)
        {
            base.AddItem(project, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Project project)
        {
            base.RemoveLine(project);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
