window.volunteerQrShare = {
    async tryShareQrImage(dataUrl, fileName, title, text, url) {
        if (!navigator.share || !navigator.canShare) {
            return false;
        }

        try {
            const response = await fetch(dataUrl);
            const blob = await response.blob();
            const file = new File([blob], fileName, { type: blob.type || 'image/png' });
            const payload = { title, text, url, files: [file] };

            if (!navigator.canShare(payload)) {
                return false;
            }

            await navigator.share(payload);
            return true;
        } catch (error) {
            if (error && error.name === 'AbortError') {
                return false;
            }

            return false;
        }
    },

    openWhatsApp(phoneNumber, text) {
        const sanitized = (phoneNumber || '').replace(/[^\d]/g, '');
        const url = `https://wa.me/${sanitized}?text=${encodeURIComponent(text || '')}`;
        window.open(url, '_blank', 'noopener,noreferrer');
    },

    openEmail(email, subject, body) {
        const address = encodeURIComponent(email || '');
        const emailSubject = encodeURIComponent(subject || '');
        const emailBody = encodeURIComponent(body || '');
        window.location.href = `mailto:${address}?subject=${emailSubject}&body=${emailBody}`;
    }
};
