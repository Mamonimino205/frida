# 解析&加密 cocos2d 功能里面的luac脚本

## 用法

```sh
usage: cocos2d_luac_decrypt.py [-h] [-f APKFILE] [-o OUTPUT] [-d DIR]
                               [-s SIGN] [-k KEY] [-e ENCRYPT]

cocos2d luac decrypt tool

optional arguments:
  -h, --help  show this help message and exit
  -f APKFILE  apk file
  -o OUTPUT   output dir
  -d DIR      luac dir
  -s SIGN     xxtea sign
  -k KEY      xxtea key

example:
    cocos2d_luac_decrypt.py -f 1.apk -o output                       # Y auto parse apk
    cocos2d_luac_decrypt.py -f 1.apk -s aaaaaaa -k bbbbbbb           # Y
    cocos2d_luac_decrypt.py -f 1.apk -o output -s aaaaaaa -k bbbbbbb # Y
    cocos2d_luac_decrypt.py -d dir -s aaaaaaa -k bbbbbbb             # Y
    cocos2d_luac_decrypt.py -d dir -s aaaaaaa -k bbbbbbb -e         # encrypt lua
```