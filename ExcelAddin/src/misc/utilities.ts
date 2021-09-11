export function castToNumberOrNull(value: any): number {
    return (value === 0 || value === '0') ? 0 : (+value || null);
}