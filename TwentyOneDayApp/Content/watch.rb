require 'fssm'

puts "Watching folder..."

COMMAND = "compass compile"

FSSM.monitor('.') do
    update do |b, r|
        if r =~ /\.scss$/
            puts "Updated file #{r} so executing #{COMMAND}"
            puts `#{COMMAND}`
        end
        # puts "Someone changed the file '#{r}' into '#{b}'"
    end
    create do |b, r|
        if r =~ /\.scss$/
            puts "Created file #{r} so executing #{COMMAND}"
            puts `#{COMMAND}`
        end
        # puts "Someone creates the file '#{r}' into '#{b}'"
    end
    delete do |b, r|
        if r =~ /\.scss$/
            puts "Deleted file #{r} so executing #{COMMAND}"
            puts `#{COMMAND}`
        end
        # puts "Someone deletes the file '#{r}' into '#{b}'"
    end
end


