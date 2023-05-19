# Bluetooth RSSI-based localizer

This project tracks coordinates of Bluetooth devices using [trilateration](https://en.wikipedia.org/wiki/Trilateration) (process similar to the one used by the GPS) in a given space which contains at least 3 ESP-32 based probes collecting RSSI data of the devices. Those probes post device identifiers along with RSSIs to the .NET 6-based API which, if available, computes the position of the device and exposing it trough Web API.

## Project state

This is work in progress.

## Repo structure

- `esp32-localizer-firmware` - code of the firmware for the ESP32 using PlatfromIO with Arduino framework acting as a probe 
- `LocalizerApi` - code of the .NET 6 Web API which collects data from probes on some endpoints and exposing localization results trough others