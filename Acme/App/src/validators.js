export function uniqueMail(value) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve(value === 'finn');
        }, 500);
    });
}
