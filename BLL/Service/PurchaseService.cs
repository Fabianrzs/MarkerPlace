using BLL.Interface;
using BLL.Response;
using BLL.Service;
using DAL.Interface;
using DAL.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseDetailRepository _purchaseDetailRepository;
        private readonly IConnectionManager _connectionManager;

        public PurchaseService(IPurchaseRepository purchaseRepository, IConnectionManager connectionManager,
            IPurchaseDetailRepository purchaseDetailRepository, IProductRepository productRepository)
        {
            _purchaseRepository = purchaseRepository;
            _connectionManager = connectionManager;
            _purchaseDetailRepository = purchaseDetailRepository;
            _productRepository = productRepository; 
        }
        public EntityResponse<Purchase> getPurchaseBy(int idUser)
        {
            try
            {
                _connectionManager.Open();

                var purchases = _purchaseRepository.GetAll().FindAll(x=> x.IdUser == idUser).ToList();
                var details = _purchaseDetailRepository.GetAll();
                var products = _productRepository.GetAll();

                if (purchases == null || purchases.Count == 0)
                {
                    return new EntityResponse<Purchase>($"No se encontraron compras registradas");
                }

                foreach (var purchase in purchases)
                {
                    purchase.PurchaseDetails = details.FindAll(x=>x.IdPurchase == purchase.Id).ToList();

                    foreach (var item in purchase.PurchaseDetails)
                    {
                        item.Product = products.FirstOrDefault(x => x.Id == item.IdProduct);
                    }
                }

                return new EntityResponse<Purchase>(purchases);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al consultar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
        public EntityResponse<Purchase> RealizatePurchase(Purchase purchase)
        {
            try
            {

                //id Compra

                _connectionManager.Open();

                purchase.CalculateFullValue();
                purchase.Buy();
                
                _purchaseRepository.Update(purchase);

                int IdPurchase = _purchaseRepository.getLatesrId();

                if (IdPurchase == 0)
                {
                    return new EntityResponse<Purchase>($"No se puede realizar la compra");
                }

                var productos = _productRepository.GetAll();

                foreach (var item in purchase.PurchaseDetails)
                {
                    item.IdPurchase = IdPurchase;
                    item.CaculateValue(productos.Find(x => x.Id == item.IdProduct).Value);
                    _purchaseDetailRepository.Create(item);
                }

                    var products = _productRepository.GetAll();

                foreach (var item in purchase.PurchaseDetails)
                {
                    var product = products.FirstOrDefault(x => x.Id == item.IdProduct);
                    product.Descount(item.Amount);
                    _productRepository.Update(product);
                }

                return new EntityResponse<Purchase>(purchase);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al crear la compra {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
        //public EntityResponse<Purchase> SaveOnTheCar(Purchase purchase)
        //{
        //    try
        //    {

        //        //idproducto y cantidad

        //        _connectionManager.Open();

        //        purchase.CalculateFullValue();

        //        _purchaseRepository.Create(purchase);

        //        int IdPurchase = _purchaseRepository.getLatesrId();

        //        if (IdPurchase == 0)
        //        {
        //            return new EntityResponse<Purchase>($"No se puedo agregar la al carrito");
        //        }

        //        var productos = _productRepository.GetAll();

        //        foreach (var item in purchase.PurchaseDetails)
        //        {
        //            item.IdPurchase = IdPurchase;
        //            item.CaculateValue(productos.Find(x=>x.Id == item.IdProduct).Value);
        //            _purchaseDetailRepository.Create(item);
        //        }

        //        return new EntityResponse<Purchase>(purchase);

        //    }
        //    catch (Exception e)
        //    {
        //        return new EntityResponse<Purchase>($"Se presento el siguiente problema al crear la compra {e.Message}");
        //    }
        //    finally { _connectionManager.Close(); }
        //}
        public EntityResponse<Purchase> ChangeState(int id, int state)
        {
            try
            {
                _connectionManager.Open();

                var status = _purchaseRepository.ChangeState(state, id);

                if (status == 0)
                {
                    return new EntityResponse<Purchase>($"No se puedo eliminar la compra");
                }

                return new EntityResponse<Purchase>("compra Eliminada con exito", false);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al eliminar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
        public EntityResponse<Purchase> Create(Purchase purchase)
        {
            try
            {
                _connectionManager.Open();

                Purchase purchaseFind = _purchaseRepository.GetBy<int>(purchase.Id);

                if (purchaseFind != null)
                {
                    return new EntityResponse<Purchase>($"No se puede crear la compra, {purchase.Id} ya se encuentra en uso");
                }

                _purchaseRepository.Create(purchase);

                return new EntityResponse<Purchase>(purchase);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al crear la compra {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
        public EntityResponse<Purchase> Edit(Purchase purchase)
        {
            try
            {
                _connectionManager.Open();

                Purchase purchaseFind = _purchaseRepository.GetBy<int>(purchase.Id);

                if (purchaseFind == null)
                {
                    return new EntityResponse<Purchase>($"No se puede editar la compra, {purchase.Id} es invalido");
                }

                _purchaseRepository.Update(purchase);


                return new EntityResponse<Purchase>(purchase);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al editar la compra {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
        public EntityResponse<Purchase> GetAll()
        {
            try
            {
                _connectionManager.Open();

                List<Purchase> purchases = new List<Purchase>();
                purchases = _purchaseRepository.GetAll();

                if (purchases == null || purchases.Count == 0)
                {
                    return new EntityResponse<Purchase>($"No se encontraron compras registradas");
                }

                return new EntityResponse<Purchase>(purchases);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al consultar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
        public EntityResponse<Purchase> GetById(int id)
        {
            try
            {
                _connectionManager.Open();

                Purchase purchaseFind = _purchaseRepository.GetBy<int>(id);

                if (purchaseFind == null)
                {
                    return new EntityResponse<Purchase>($"No se puedo encontrar la compra solicitada");
                }

                return new EntityResponse<Purchase>(purchaseFind);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al buscar {id} {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
    }
}
