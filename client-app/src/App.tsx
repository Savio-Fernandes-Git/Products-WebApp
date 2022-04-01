import {
    ChakraProvider,
    Box,
    theme,
    Container,
    Grid,
    GridItem,
    VStack,
    Heading,
    Text,
    Image,
} from "@chakra-ui/react";
import axios from "axios";
import { useEffect, useState } from "react";
import { Product } from "./models/product";

const App = () => {
    const [products, setProducts] = useState<Product[]>([]);

    useEffect(() => {
        axios.get("http://localhost:5133/api/products").then((response) => {
            console.log(response.data);
            setProducts(response.data);
        });
    }, []);

    return (
        <ChakraProvider theme={theme}>
            <Box bgColor={"whitesmoke"} p={2}>
                <Container maxW="container.xl">
                    <Heading mb={2}>Products</Heading>
                    <Grid templateColumns="repeat(4,1fr)" gap={6}>
                        {products.map((product) => (
                            <GridItem key={product.productId}>
                                <Box
                                    bgColor="whiteAlpha.800"
                                    maxW="sm"
                                    borderWidth="1px"
                                    borderRadius="lg"
                                    overflow="hidden"
                                    p={1}
                                >
                                    <VStack>
                                        <Image src={product.imageUrl} />
                                        <Heading size="md">
                                            {product.name}
                                        </Heading>
                                        <Text fontWeight={"light"}>
                                            {product.description}
                                        </Text>
                                        <Text>
                                            {product.price} {product.currency}
                                        </Text>
                                    </VStack>
                                </Box>
                            </GridItem>
                        ))}
                    </Grid>
                </Container>
            </Box>
        </ChakraProvider>
    );
};
export default App;
