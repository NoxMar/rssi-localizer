#ifndef UTIL_H
#define UTIL_H

#include <WiFi.h>
#include <ArduinoLog.h>

#include "config.h"

void setupWiFi()
{
    WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
    for (int i = 0; i < WIFI_INITIAL_RETRIES; i++)
    {
        delay(WIFI_INTIAL_RETRY_DELAY);
        if (WiFi.status() == WL_CONNECTED)
        {
            break;
        }
        Log.verboseln("WiFi connection attempt %d failed", i + 1);
    }
    if (WiFi.status() == WL_CONNECTED)
    {
        Log.infoln("Connected to WiFi with SSID: %s", WIFI_SSID);
    }
    else
    {
        Log.errorln("Wasn't able to connect to WiFi %s with %d retries",
                    WIFI_SSID,
                    WIFI_INITIAL_RETRIES);
    }
}
#endif /* UTIL_H */