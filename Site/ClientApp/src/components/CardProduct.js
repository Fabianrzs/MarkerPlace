export default function CardProduct(props){
    const {image, name, descriptions, value, category, availble} = props
    return(
        <>
            <div className="card p-5 m-5 " style={{width: "20rem"}}>
                <img src={image} className="card-img-top" alt={name}/>
                    <div className="card-body">
                        <h3 className="card-title">{name}</h3>
                        <p className="card-text text-primary">{category}</p>
                        <p className="card-text">{descriptions}</p>
                        <span className="card-text">{availble}</span>
                        <h5 className={"text-primary"}>{value}</h5>
                        <a className = "btn btn-success">Agregar</a>
                    </div>
            </div>
        </>
    )
}
