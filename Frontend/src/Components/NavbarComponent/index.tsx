import { Container, Nav, Navbar } from "react-bootstrap";

export function NavbarComponent(){
    return (
        <Navbar bg="dark" variant="dark">
            <Container>
                <Navbar.Brand>
                    GeekShopping
                </Navbar.Brand>
                <Nav>
                    <Nav.Link>Home</Nav.Link>
                    <Nav.Link>Products</Nav.Link>
                </Nav>
            </Container>
        </Navbar>
    )
}