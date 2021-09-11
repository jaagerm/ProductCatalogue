import { apiUrl } from '../misc/config';
import { IProduct } from '../models/products';

export const getFromApi = async (): Promise<IProduct[]> => {
    const endpointPath = apiUrl + '/product';
    let response: Response;

    try {
        response = await fetch(endpointPath, { method: 'GET' });
    } catch (error) {
        throw new Error(`Failed to get product data`
           +  ` from ${endpointPath}, errorMessage: ${error.message}`);
    }

    if (!response.ok) {
        const errorMessage = await response.text();
        const statusCode = response.status;
        throw new Error(
            `Failed to get product data`
               + ` from ${endpointPath}, statusCode: ${statusCode}, errorMessage: ${errorMessage}`
        );
    }

    const body = await response.json();

    return body as IProduct[];
};