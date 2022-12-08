import CardProduct from "../../components/CardProduct";
import {useEffect, useState} from "react";
import ProductService from "../../services/productService";
import productService from "../../services/productService";
import Loading from "../../components/common/Loading";
export default function Products(){

    const [products, setProducts] = useState([])

    const [loadData, setLoadData] = useState(false)

    const {getAll} = productService

    const loadProducts = async () =>{
        const response = await getAll()
        console.log(response)
        //setProducts(setProducts)
        setLoadData(true)
    }

    useEffect(()=>{
        loadProducts().then()
    },[])

    /*const products = [
        {image : "[hat", name : "Pepe", category : "Juas",
            descriptions: "Juaz Juaz Juaz Juaz sss sss sss sssss sssss ssssss adda dasd asdasdasd asdasdasd", value:200000},
        {image : "[hat", name : "Pepe",category : "Juas",
            descriptions: "Juaz Juaz Juaz Juaz", value:200000},
        {image : "[hat", name : "Pepe",category : "Juas",
            descriptions: "Juaz Juaz Juaz Juaz", value:200000},
        {image : "[hat", name : "Pepe",category : "Juas",
            descriptions: "Juaz Juaz Juaz Juaz", value:200000},
        {image : "[hat", name : "Pepe",category : "Juas",
            descriptions: "Juaz Juaz Juaz Juaz", value:200000},
        {image : "[hat", name : "Pepe",category : "Juas",
            descriptions: "Juaz Juaz Juaz Juaz", value:200000},
        {image : "[hat", name : "Pepe",category : "Juas",
            descriptions: "Juaz Juaz Juaz Juaz", value:200000},
    ]*/
    if(!!loadData){
        return <Loading/>
    }

    return(
        <div className="row">
            {products && products.map((item, index)=><CardProduct key={index}
              category = {item.category} descriptions={item.descriptions} value={item.value} />)}

        </div>
    )
}
