import axios from "axios";
import { useEffect, useState } from "react"
import { Button, Container, Table } from "react-bootstrap";
import { NavbarComponent } from "../../Components/NavbarComponent";
import { ProductModel } from "../../Models/product-model";

export function List() {
    const [products, setProducts] = useState([] as ProductModel[]);

    useEffect(() => {
        axios.get<ProductModel[]>("http://localhost:5283/api/v1/Product").then(res => {
            setProducts(res.data);
        }).catch(err => {
            console.error(err);
        })
    }, [])

    return (
        <>
            <NavbarComponent />
            <Container>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Category</th>
                            <th>Price</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {products.map(p => {
                            return (
                                <tr>
                                    <td>
                                        {p.name}
                                    </td>
                                    <td>
                                        {p.categoryName}
                                    </td>
                                    <td>
                                        {p.price}
                                    </td>
                                    <td>
                                        <Button></Button>
                                    </td>
                                    <td>
                                        <Button></Button>
                                    </td>
                                </tr>

                            )
                        })}
                    </tbody>
                </Table>
            </Container>
        </>
    )
}