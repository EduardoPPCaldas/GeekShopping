import axios from "axios";
import { useEffect, useState } from "react"
import { ProductModel } from "../../Models/product-model";

export function LandingPage(){
    const [products, setProducts] = useState([] as ProductModel[]);
    
    useEffect(() => {
        axios.get<ProductModel[]>("http://localhost:5283/api/v1/Product").then(res => {
            setProducts(res.data);
        }).catch(err => {
            console.error(err);
        })
    }, [])

    return (
        <div>
            { products.map(product => {
                return (
                    <h1 key={product.id}>{product.name}</h1>
                )
            })}
        </div>
    )
}