export function validSerial(value) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve(value === 'finn');
        }, 500);
    });
}
