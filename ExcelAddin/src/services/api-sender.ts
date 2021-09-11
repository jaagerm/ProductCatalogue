export async function send(url: string, data: any) {
    const response = await fetch(url, data);

    await validateResponse(response, url);
}

async function validateResponse(response: Response, url: string) {
    if (response.ok) {
        return;
    }

    const errorJson = await response.json();

    if (errorJson.error) {
        throw new Error(`One or more errors occured ${url}! ${JSON.stringify(errorJson.error)}`);
    }

    throw new Error(`Request failed to ${url}: ${JSON.stringify(errorJson)}`);
}