import {
    ChakraProvider,
    Box,
    theme,
    Container,
    Grid,
    GridItem,
    VStack,
    Image,
    Heading,
    Text,
} from "@chakra-ui/react";
import axios from "axios";
import { useEffect, useState } from "react";
import { Product } from "./models/product";

const App = () => {
    const [products, setProducts] = useState<Product[]>([]);

    useEffect(() => {
        axios.get("http://localhost:5133/api/products").then((response) => {
            console.log(response);
            setProducts(response.data);
        });
    }, []);

    return (
        <ChakraProvider theme={theme}>
            <Box>
                <Container maxW="container.xl">
                    <Heading>
                        Products
                    </Heading>
                    <Grid templateColumns="repeat(4,1fr)" gap={6}>
                        {products.map((product) => 
                        <GridItem>
                            <Box key={product.productId} bgColor="whitesmoke">
                                <VStack>
                                    <Heading size="md">{product.name}</Heading>
                                    <Text>{product.price} KD</Text>
                                </VStack>
                            </Box>
                        </GridItem>
                        )}
                    </Grid>
                </Container>
            </Box>
        </ChakraProvider>
    );
};
export default App;
