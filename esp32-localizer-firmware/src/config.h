#ifndef CONFIG_H
#define CONFIG_H

/* === WiFi Settings === */
#define WIFI_SSID "Pixel_8223"
#define WIFI_PASSWORD "Tuxpega1357"
#define WIFI_INITIAL_RETRIES 4
#define WIFI_INTIAL_RETRY_DELAY 1000

/* ==== API Settings ==== */
#define API_BASE_URL "http://192.168.6.209:5005/api"

/* ==== General Settings ==== */
#define SERIAL_BAUD_RATE 115200
#define INITIAL_DELAY 4000
#define INITIAL_DELAY 4000

/* ==== Scan Settings ==== */
#define SCAN_DURATION 60
// active scan uses more power but is more reliable and finds devices faster
#define SCAN_ACTIVE_MODE true

#endif /* CONFIG_H */