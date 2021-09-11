import * as ExcelService from './excel-service';
import { IOutputData } from '../models/output-data';
import { IProduct } from '../models/product';
import { castToNumberOrNull } from '../misc/utilities';
import { dataServiceApiUrl } from '../config';
import * as ApiSender from './api-sender';

export async function sendData(
    employeeId: string,
    messageCallback: (message: string) => void) {
    const excelData = await getProducts();
    
    const data = {
        employeeId,
        products: excelData
    } as IOutputData

    await callApi(data);

    messageCallback('Data sent successfully!');
}

async function getProducts() {
    const excelRows = await ExcelService.getRows("Data");

    const products: IProduct[] = [];

    excelRows.forEach((row: any[]) => {
        products.push({
            id: row[0],
            name: row[1],
            producer: row[2],
            quantity: castToNumberOrNull(row[3])
        });
    });

    return products;
}

async function callApi(outputData: IOutputData) {
    const url = dataServiceApiUrl + 'product/';
    const putData = {
        method: 'PUT',
        body: JSON.stringify(outputData),
        headers: {
            'Content-Type': 'application/json; charset=utf-8'
        }
    };

    await ApiSender.send(url, putData);
}