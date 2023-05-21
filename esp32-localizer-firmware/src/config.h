#ifndef CONFIG_H
#define CONFIG_H

/* === WiFi Settings === */
#define WIFI_SSID "<YOUR_SSID>"
#define WIFI_PASSWORD "<YOUR_WIFI_PASSWORD>"
#define WIFI_INITIAL_RETRIES 4
#define WIFI_INTIAL_RETRY_DELAY 1000

/* ==== General Settings ==== */
#define SERIAL_BAUD_RATE 115200
#define INITIAL_DELAY 4000
#define INITIAL_DELAY 4000

/* ==== Scan Settings ==== */
#define SCAN_DURATION 60
// active scan uses more power but is more reliable and finds devices faster
#define SCAN_ACTIVE_MODE true

#endif /* CONFIG_H */