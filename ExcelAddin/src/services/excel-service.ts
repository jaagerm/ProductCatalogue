export async function getRows(sheetName: string): Promise<any[][]> {
    return await Excel.run(async context => {
        const sheet = context.workbook.worksheets.getItem(sheetName);
        const range = sheet.getUsedRange();
        range.load('values');
        await context.sync();

        const rows = range.values.slice(1).filter(r => r[0]);

        return rows;
    });
}