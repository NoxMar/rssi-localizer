#include "bluetooth_scanner.h"
#include <ArduinoLog.h>

RssiScanner::RssiScanner(int scanDurationSeconds = 120, bool activeMode = true)
{
    this->scanDurationsSeconds = scanDurationSeconds;
    this->activeMode = activeMode;
}

void RssiScanner::scan(void (*onFound)(RssiScanner *context, BLEAdvertisedDevice *result))
{
    BLEDevice::init("");
    BLEScan *pBLEScan = BLEDevice::getScan(); // Begins new scan
    pBLEScan->setActiveScan(activeMode);
    pBLEScan->setInterval(0x50);
    pBLEScan->setWindow(0x30);

    Log.infoln("Starting scan of length %d seconds", scanDurationsSeconds);
    BLEScanResults results = pBLEScan->start(scanDurationsSeconds);

    int deviceCount = results.getCount();
    Log.infoln("Scan finished, found %d devices", deviceCount);
    for (int i = 0; i < deviceCount; i++)
    {
        BLEAdvertisedDevice device = results.getDevice(i);
        const char *address = device.getAddress().toString().c_str();
        int rssi = device.getRSSI();
        Log.infoln("Device found: address=\"%s\", RSSI=\"%d\"", address, rssi);
        onFound(this, &device);
    }
}