import { Counter } from "../pages/Counter";
import { FetchData } from "../pages/FetchData";
import { Home } from "../pages/Home";
import Login from "../pages/users/Login";
import Register from "../pages/users/Register";
import Products from "../pages/products/Products";
import ProductRegister from "../pages/products/ProductsAdd";

const AppRoutes = [
  {
    index: true,
    element: <Login />,
    logeade: false
  },
  {
    path: '/register',
    element: <Register />,
    logeade: false
  },
  {
    path: '/home',
    element: <Home />,
    logeade: false
  },

  {
    path: '/productRegister',
    element: <ProductRegister />,
    logeade: false
  },
  {
    path: '/product',
    element: <Products />,
    logeade: false
  },
  {
    path: '/counter',
    element: <Counter />,
    logeade: false
  },
  {
    path: '/fetch-data',
    element: <FetchData />,
    logeade: false
  }
];

export default AppRoutes;
