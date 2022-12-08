import CardProduct from "../../components/CardProduct";

export default function Products(){

    const products = [
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
    ]

    return(
        <div className="row">
            {products.map((item, index)=><CardProduct key={index} category = {item.category}
                                                      image={item.image} name={item.name}
                                                      descriptions={item.descriptions} value={item.value} />)}
        </div>
    )
}
