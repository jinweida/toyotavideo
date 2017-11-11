@echo off
C:\video\WindowsFormsApplication1\bin\Debug\ffmpeg\ffmpeg.exe
ffmpeg -y -ss 00:00:05 -i %2 -t 10 -vcodec copy -an tmp/t.mp4 -loglevel 16
ffmpeg -y -i tmp/t.mp4 -b:v 1024k -s 1080x640 -f mpegts tmp/1.ts -loglevel 16
ffmpeg -y -ss 00:00:15 -i %2 -t 10 -vcodec copy -an tmp/t.mp4 -loglevel 16
ffmpeg -y -i tmp/t.mp4 -b:v 1024k -s 1080x640 -f mpegts tmp/2.ts -loglevel 16
ffmpeg -y -ss 00:00:25 -i %2 -t 17 -vcodec copy -an tmp/t.mp4 -loglevel 16
ffmpeg -y -i tmp/t.mp4 -b:v 1024k -s 1080x640 -f mpegts tmp/3.ts -loglevel 16
ffmpeg -y -ss 00:00:05 -i %3 -t 15 -vcodec copy -an tmp/t.mp4 -loglevel 16
ffmpeg -y -i tmp/t.mp4 -b:v 1024k -s 1080x640 -f mpegts tmp/4.ts -loglevel 16
ffmpeg -y -ss 0 -i bg.mp3 -t 52 -acodec copy tmp/b.mp3 -loglevel 16
ffmpeg -y -i "concat:tmp/1.ts|tmp/2.ts|tmp/3.ts|tmp/4.ts" -i tmp/b.mp3 -c copy tmp/body.ts -loglevel 16
ffmpeg -y -i "concat:header.ts|tmp/body.ts|footer.ts" -vcodec h264 tmp/finish.mp4 -loglevel 16
move %CD%\tmp\finish.mp4  %CD%\output\%1.mp4